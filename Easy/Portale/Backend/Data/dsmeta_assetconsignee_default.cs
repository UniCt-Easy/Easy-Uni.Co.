
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
[System.Xml.Serialization.XmlRoot("dsmeta_assetconsignee_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_assetconsignee_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable manager 		=> (MetaTable)Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetconsignee 		=> (MetaTable)Tables["assetconsignee"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_assetconsignee_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_assetconsignee_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_assetconsignee_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_assetconsignee_default.xsd";

	#region create DataTables
	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new MetaTable("manager");
	tmanager.defineColumn("active", typeof(string));
	tmanager.defineColumn("idman", typeof(int),false);
	tmanager.defineColumn("title", typeof(string),false);
	Tables.Add(tmanager);
	tmanager.defineKey("idman");

	//////////////////// ASSETCONSIGNEE /////////////////////////////////
	var tassetconsignee= new MetaTable("assetconsignee");
	tassetconsignee.defineColumn("active", typeof(string));
	tassetconsignee.defineColumn("idinventoryagency", typeof(int),false);
	tassetconsignee.defineColumn("idman", typeof(int));
	tassetconsignee.defineColumn("lt", typeof(DateTime));
	tassetconsignee.defineColumn("lu", typeof(string));
	tassetconsignee.defineColumn("qualification", typeof(string));
	tassetconsignee.defineColumn("start", typeof(DateTime),false);
	tassetconsignee.defineColumn("title", typeof(string));
	Tables.Add(tassetconsignee);
	tassetconsignee.defineKey("idinventoryagency", "start");

	#endregion


	#region DataRelation creation
	var cPar = new []{manager.Columns["idman"]};
	var cChild = new []{assetconsignee.Columns["idman"]};
	Relations.Add(new DataRelation("FK_assetconsignee_manager_idman",cPar,cChild,false));

	#endregion

}
}
}
