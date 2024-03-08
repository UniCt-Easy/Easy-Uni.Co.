
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
[System.Xml.Serialization.XmlRoot("dsmeta_subassetloadsubassetloadsub_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_subassetloadsubassetloadsub_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable subassetloadsubdefaultview 		=> (MetaTable)Tables["subassetloadsubdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetloadsubdefaultview 		=> (MetaTable)Tables["assetloadsubdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable subassetloadsubassetloadsub 		=> (MetaTable)Tables["subassetloadsubassetloadsub"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_subassetloadsubassetloadsub_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_subassetloadsubassetloadsub_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_subassetloadsubassetloadsub_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_subassetloadsubassetloadsub_default.xsd";

	#region create DataTables
	//////////////////// SUBASSETLOADSUBDEFAULTVIEW /////////////////////////////////
	var tsubassetloadsubdefaultview= new MetaTable("subassetloadsubdefaultview");
	tsubassetloadsubdefaultview.defineColumn("idman", typeof(int));
	tsubassetloadsubdefaultview.defineColumn("idsubassetloadsub", typeof(int),false);
	tsubassetloadsubdefaultview.defineColumn("manager_title", typeof(string));
	Tables.Add(tsubassetloadsubdefaultview);
	tsubassetloadsubdefaultview.defineKey("idsubassetloadsub");

	//////////////////// ASSETLOADSUBDEFAULTVIEW /////////////////////////////////
	var tassetloadsubdefaultview= new MetaTable("assetloadsubdefaultview");
	tassetloadsubdefaultview.defineColumn("assetload_description", typeof(string));
	tassetloadsubdefaultview.defineColumn("assetload_idassetloadkind", typeof(int));
	tassetloadsubdefaultview.defineColumn("assetload_nassetload", typeof(int));
	tassetloadsubdefaultview.defineColumn("assetload_yassetload", typeof(int));
	tassetloadsubdefaultview.defineColumn("assetloadkind_codeassetloadkind", typeof(string));
	tassetloadsubdefaultview.defineColumn("assetloadkind_description", typeof(string));
	tassetloadsubdefaultview.defineColumn("assetloadsub_ct", typeof(DateTime),false);
	tassetloadsubdefaultview.defineColumn("assetloadsub_cu", typeof(string),false);
	tassetloadsubdefaultview.defineColumn("assetloadsub_idsubstate", typeof(int));
	tassetloadsubdefaultview.defineColumn("assetloadsub_lt", typeof(DateTime),false);
	tassetloadsubdefaultview.defineColumn("assetloadsub_lu", typeof(string),false);
	tassetloadsubdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tassetloadsubdefaultview.defineColumn("idassetload", typeof(int),false);
	tassetloadsubdefaultview.defineColumn("idassetloadsub", typeof(int),false);
	tassetloadsubdefaultview.defineColumn("idman", typeof(int));
	tassetloadsubdefaultview.defineColumn("manager_title", typeof(string));
	tassetloadsubdefaultview.defineColumn("substate_description", typeof(string));
	Tables.Add(tassetloadsubdefaultview);
	tassetloadsubdefaultview.defineKey("idassetload", "idassetloadsub");

	//////////////////// SUBASSETLOADSUBASSETLOADSUB /////////////////////////////////
	var tsubassetloadsubassetloadsub= new MetaTable("subassetloadsubassetloadsub");
	tsubassetloadsubassetloadsub.defineColumn("idassetloadsub", typeof(int),false);
	tsubassetloadsubassetloadsub.defineColumn("idsubassetloadsub", typeof(int),false);
	Tables.Add(tsubassetloadsubassetloadsub);
	tsubassetloadsubassetloadsub.defineKey("idassetloadsub", "idsubassetloadsub");

	#endregion


	#region DataRelation creation
	var cPar = new []{subassetloadsubdefaultview.Columns["idsubassetloadsub"]};
	var cChild = new []{subassetloadsubassetloadsub.Columns["idsubassetloadsub"]};
	Relations.Add(new DataRelation("FK_subassetloadsubassetloadsub_subassetloadsubdefaultview_idsubassetloadsub",cPar,cChild,false));

	cPar = new []{assetloadsubdefaultview.Columns["idassetloadsub"]};
	cChild = new []{subassetloadsubassetloadsub.Columns["idassetloadsub"]};
	Relations.Add(new DataRelation("FK_subassetloadsubassetloadsub_assetloadsubdefaultview_idassetloadsub",cPar,cChild,false));

	#endregion

}
}
}
