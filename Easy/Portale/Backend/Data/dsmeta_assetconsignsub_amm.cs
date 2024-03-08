
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
[System.Xml.Serialization.XmlRoot("dsmeta_assetconsignsub_amm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_assetconsignsub_amm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable substate 		=> (MetaTable)Tables["substate"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable manager 		=> (MetaTable)Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetsegview 		=> (MetaTable)Tables["assetsegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetconsignsub 		=> (MetaTable)Tables["assetconsignsub"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_assetconsignsub_amm(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_assetconsignsub_amm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_assetconsignsub_amm";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_assetconsignsub_amm.xsd";

	#region create DataTables
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

	//////////////////// ASSETSEGVIEW /////////////////////////////////
	var tassetsegview= new MetaTable("assetsegview");
	tassetsegview.defineColumn("dropdown_title", typeof(string),false);
	tassetsegview.defineColumn("idasset", typeof(int),false);
	tassetsegview.defineColumn("idpiece", typeof(int),false);
	Tables.Add(tassetsegview);
	tassetsegview.defineKey("idasset", "idpiece");

	//////////////////// ASSETCONSIGNSUB /////////////////////////////////
	var tassetconsignsub= new MetaTable("assetconsignsub");
	tassetconsignsub.defineColumn("ct", typeof(DateTime));
	tassetconsignsub.defineColumn("cu", typeof(string));
	tassetconsignsub.defineColumn("idasset", typeof(int));
	tassetconsignsub.defineColumn("idassetconsignsub", typeof(int),false);
	tassetconsignsub.defineColumn("idassetload", typeof(int),false);
	tassetconsignsub.defineColumn("idassetloadkind", typeof(int));
	tassetconsignsub.defineColumn("idassetloadsub", typeof(int),false);
	tassetconsignsub.defineColumn("idassetlocation", typeof(int));
	tassetconsignsub.defineColumn("idinv", typeof(int));
	tassetconsignsub.defineColumn("idinventory", typeof(int));
	tassetconsignsub.defineColumn("idinventorykind", typeof(int));
	tassetconsignsub.defineColumn("idlocation", typeof(int));
	tassetconsignsub.defineColumn("idman", typeof(int));
	tassetconsignsub.defineColumn("idpiece", typeof(int));
	tassetconsignsub.defineColumn("idsubstate", typeof(int));
	tassetconsignsub.defineColumn("lt", typeof(DateTime));
	tassetconsignsub.defineColumn("lu", typeof(string));
	tassetconsignsub.defineColumn("nassetacquire", typeof(int));
	tassetconsignsub.defineColumn("subdate", typeof(DateTime));
	Tables.Add(tassetconsignsub);
	tassetconsignsub.defineKey("idassetconsignsub", "idassetload", "idassetloadsub");

	#endregion


	#region DataRelation creation
	var cPar = new []{substate.Columns["idsubstate"]};
	var cChild = new []{assetconsignsub.Columns["idsubstate"]};
	Relations.Add(new DataRelation("FK_assetconsignsub_substate_idsubstate",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{assetconsignsub.Columns["idman"]};
	Relations.Add(new DataRelation("FK_assetconsignsub_manager_idman",cPar,cChild,false));

	cPar = new []{assetsegview.Columns["idasset"]};
	cChild = new []{assetconsignsub.Columns["idasset"]};
	Relations.Add(new DataRelation("FK_assetconsignsub_assetsegview_idasset",cPar,cChild,false));

	#endregion

}
}
}
