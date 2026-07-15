/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_exportdefinitionflowchart_flowchart"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_exportdefinitionflowchart_flowchart: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable exportdefinition 		=> (MetaTable)Tables["exportdefinition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable exportdefinitionflowchart 		=> (MetaTable)Tables["exportdefinitionflowchart"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_exportdefinitionflowchart_flowchart(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_exportdefinitionflowchart_flowchart (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_exportdefinitionflowchart_flowchart";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_exportdefinitionflowchart_flowchart.xsd";

	#region create DataTables
	//////////////////// EXPORTDEFINITION /////////////////////////////////
	var texportdefinition= new MetaTable("exportdefinition");
	texportdefinition.defineColumn("active", typeof(string));
	texportdefinition.defineColumn("ct", typeof(DateTime),false);
	texportdefinition.defineColumn("cu", typeof(string),false);
	texportdefinition.defineColumn("description", typeof(string));
	texportdefinition.defineColumn("idattach_template", typeof(int));
	texportdefinition.defineColumn("idexportdefinition", typeof(int),false);
	texportdefinition.defineColumn("idfileformat", typeof(string),false);
	texportdefinition.defineColumn("idmenuweb", typeof(int),false);
	texportdefinition.defineColumn("lt", typeof(DateTime),false);
	texportdefinition.defineColumn("lu", typeof(string),false);
	texportdefinition.defineColumn("outputfilename", typeof(string));
	texportdefinition.defineColumn("procedurename", typeof(string));
	texportdefinition.defineColumn("timeoutseconds", typeof(int));
	texportdefinition.defineColumn("title", typeof(string));
	Tables.Add(texportdefinition);
	texportdefinition.defineKey("idexportdefinition");

	//////////////////// EXPORTDEFINITIONFLOWCHART /////////////////////////////////
	var texportdefinitionflowchart= new MetaTable("exportdefinitionflowchart");
	texportdefinitionflowchart.defineColumn("ct", typeof(DateTime),false);
	texportdefinitionflowchart.defineColumn("cu", typeof(string),false);
	texportdefinitionflowchart.defineColumn("idexportdefinition", typeof(int),false);
	texportdefinitionflowchart.defineColumn("idflowchart", typeof(string),false);
	texportdefinitionflowchart.defineColumn("lt", typeof(DateTime),false);
	texportdefinitionflowchart.defineColumn("lu", typeof(string),false);
	Tables.Add(texportdefinitionflowchart);
	texportdefinitionflowchart.defineKey("idexportdefinition", "idflowchart");

	#endregion


	#region DataRelation creation
	var cPar = new []{exportdefinition.Columns["idexportdefinition"]};
	var cChild = new []{exportdefinitionflowchart.Columns["idexportdefinition"]};
	Relations.Add(new DataRelation("FK_exportdefinitionflowchart_exportdefinition_idexportdefinition",cPar,cChild,false));

	#endregion

}
}
}
