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
[System.Xml.Serialization.XmlRoot("dsmeta_exportdefinitionparameter_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_exportdefinitionparameter_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable datatype 		=> (MetaTable)Tables["datatype"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable exportdefinition 		=> (MetaTable)Tables["exportdefinition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable exportdefinitionparameter 		=> (MetaTable)Tables["exportdefinitionparameter"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_exportdefinitionparameter_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_exportdefinitionparameter_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_exportdefinitionparameter_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_exportdefinitionparameter_default.xsd";

	#region create DataTables
	//////////////////// DATATYPE /////////////////////////////////
	var tdatatype= new MetaTable("datatype");
	tdatatype.defineColumn("iddatatype", typeof(int),false);
	tdatatype.defineColumn("title", typeof(string));
	Tables.Add(tdatatype);
	tdatatype.defineKey("iddatatype");

	//////////////////// EXPORTDEFINITION /////////////////////////////////
	var texportdefinition= new MetaTable("exportdefinition");
	texportdefinition.defineColumn("active", typeof(string));
	texportdefinition.defineColumn("idexportdefinition", typeof(int),false);
	texportdefinition.defineColumn("title", typeof(string));
	Tables.Add(texportdefinition);
	texportdefinition.defineKey("idexportdefinition");

	//////////////////// EXPORTDEFINITIONPARAMETER /////////////////////////////////
	var texportdefinitionparameter= new MetaTable("exportdefinitionparameter");
	texportdefinitionparameter.defineColumn("ct", typeof(DateTime),false);
	texportdefinitionparameter.defineColumn("cu", typeof(string),false);
	texportdefinitionparameter.defineColumn("customcontrol", typeof(string));
	texportdefinitionparameter.defineColumn("datasource", typeof(string));
	texportdefinitionparameter.defineColumn("description", typeof(string),false);
	texportdefinitionparameter.defineColumn("displaymember", typeof(string));
	texportdefinitionparameter.defineColumn("filter", typeof(string));
	texportdefinitionparameter.defineColumn("help", typeof(string));
	texportdefinitionparameter.defineColumn("iddatatype", typeof(int),false);
	texportdefinitionparameter.defineColumn("idexportdefinition", typeof(int),false);
	texportdefinitionparameter.defineColumn("idexportdefinitionparameter", typeof(int),false);
	texportdefinitionparameter.defineColumn("lt", typeof(DateTime),false);
	texportdefinitionparameter.defineColumn("lu", typeof(string),false);
	texportdefinitionparameter.defineColumn("number", typeof(int));
	texportdefinitionparameter.defineColumn("selectioncode", typeof(string));
	texportdefinitionparameter.defineColumn("title", typeof(string),false);
	texportdefinitionparameter.defineColumn("valuemember", typeof(string));
	Tables.Add(texportdefinitionparameter);
	texportdefinitionparameter.defineKey("idexportdefinition", "idexportdefinitionparameter");

	#endregion


	#region DataRelation creation
	var cPar = new []{datatype.Columns["iddatatype"]};
	var cChild = new []{exportdefinitionparameter.Columns["iddatatype"]};
	Relations.Add(new DataRelation("FK_exportdefinitionparameter_datatype_iddatatype",cPar,cChild,false));

	cPar = new []{exportdefinition.Columns["idexportdefinition"]};
	cChild = new []{exportdefinitionparameter.Columns["idexportdefinition"]};
	Relations.Add(new DataRelation("FK_exportdefinitionparameter_exportdefinition_idexportdefinition",cPar,cChild,false));

	#endregion

}
}
}
