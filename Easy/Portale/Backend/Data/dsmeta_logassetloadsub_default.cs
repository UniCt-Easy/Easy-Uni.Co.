
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
[System.Xml.Serialization.XmlRoot("dsmeta_logassetloadsub_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_logassetloadsub_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable substate 		=> (MetaTable)Tables["substate"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable manager 		=> (MetaTable)Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable logassetloadsub 		=> (MetaTable)Tables["logassetloadsub"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_logassetloadsub_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_logassetloadsub_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_logassetloadsub_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_logassetloadsub_default.xsd";

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
	Tables.Add(tlogassetloadsub);
	tlogassetloadsub.defineKey("idassetloadsub", "idlogassetloadsub");

	#endregion


	#region DataRelation creation
	var cPar = new []{substate.Columns["idsubstate"]};
	var cChild = new []{logassetloadsub.Columns["idsubstate"]};
	Relations.Add(new DataRelation("FK_logassetloadsub_substate_idsubstate",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{logassetloadsub.Columns["idman"]};
	Relations.Add(new DataRelation("FK_logassetloadsub_manager_idman",cPar,cChild,false));

	#endregion

}
}
}
