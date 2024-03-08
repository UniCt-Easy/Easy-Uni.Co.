
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
[System.Xml.Serialization.XmlRoot("dsmeta_changeskind_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_changeskind_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable changes 		=> (MetaTable)Tables["changes"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable changeskind 		=> (MetaTable)Tables["changeskind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_changeskind_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_changeskind_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_changeskind_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_changeskind_default.xsd";

	#region create DataTables
	//////////////////// CHANGES /////////////////////////////////
	var tchanges= new MetaTable("changes");
	tchanges.defineColumn("idchanges", typeof(int),false);
	tchanges.defineColumn("title", typeof(string),false);
	Tables.Add(tchanges);
	tchanges.defineKey("idchanges");

	//////////////////// CHANGESKIND /////////////////////////////////
	var tchangeskind= new MetaTable("changeskind");
	tchangeskind.defineColumn("active", typeof(string),false);
	tchangeskind.defineColumn("description", typeof(string));
	tchangeskind.defineColumn("idchanges", typeof(int));
	tchangeskind.defineColumn("idchangeskind", typeof(int),false);
	tchangeskind.defineColumn("lt", typeof(DateTime),false);
	tchangeskind.defineColumn("lu", typeof(string),false);
	tchangeskind.defineColumn("sortcode", typeof(int),false);
	tchangeskind.defineColumn("title", typeof(string),false);
	Tables.Add(tchangeskind);
	tchangeskind.defineKey("idchangeskind");

	#endregion


	#region DataRelation creation
	var cPar = new []{changes.Columns["idchanges"]};
	var cChild = new []{changeskind.Columns["idchanges"]};
	Relations.Add(new DataRelation("FK_changeskind_changes_idchanges",cPar,cChild,false));

	#endregion

}
}
}
