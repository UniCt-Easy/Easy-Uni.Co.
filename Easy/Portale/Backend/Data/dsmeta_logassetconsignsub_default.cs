
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
[System.Xml.Serialization.XmlRoot("dsmeta_logassetconsignsub_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_logassetconsignsub_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable substate 		=> (MetaTable)Tables["substate"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable manager 		=> (MetaTable)Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable logassetconsignsub 		=> (MetaTable)Tables["logassetconsignsub"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_logassetconsignsub_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_logassetconsignsub_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_logassetconsignsub_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_logassetconsignsub_default.xsd";

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

	//////////////////// LOGASSETCONSIGNSUB /////////////////////////////////
	var tlogassetconsignsub= new MetaTable("logassetconsignsub");
	tlogassetconsignsub.defineColumn("ct", typeof(DateTime));
	tlogassetconsignsub.defineColumn("cu", typeof(string));
	tlogassetconsignsub.defineColumn("idassetconsignsub", typeof(int),false);
	tlogassetconsignsub.defineColumn("idassetloadsub", typeof(int),false);
	tlogassetconsignsub.defineColumn("idlogassetconsignsub", typeof(int),false);
	tlogassetconsignsub.defineColumn("idman", typeof(int),false);
	tlogassetconsignsub.defineColumn("idsubstate", typeof(int),false);
	tlogassetconsignsub.defineColumn("lt", typeof(DateTime));
	tlogassetconsignsub.defineColumn("lu", typeof(string));
	tlogassetconsignsub.defineColumn("timestamp", typeof(DateTime),false);
	Tables.Add(tlogassetconsignsub);
	tlogassetconsignsub.defineKey("idassetconsignsub", "idassetloadsub", "idlogassetconsignsub");

	#endregion


	#region DataRelation creation
	var cPar = new []{substate.Columns["idsubstate"]};
	var cChild = new []{logassetconsignsub.Columns["idsubstate"]};
	Relations.Add(new DataRelation("FK_logassetconsignsub_substate_idsubstate",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{logassetconsignsub.Columns["idman"]};
	Relations.Add(new DataRelation("FK_logassetconsignsub_manager_idman",cPar,cChild,false));

	#endregion

}
}
}
