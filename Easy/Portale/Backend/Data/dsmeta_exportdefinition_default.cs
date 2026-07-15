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
[System.Xml.Serialization.XmlRoot("dsmeta_exportdefinition_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_exportdefinition_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable datatype 		=> (MetaTable)Tables["datatype"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable exportdefinitionparameter 		=> (MetaTable)Tables["exportdefinitionparameter"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable flowchart_alias1 		=> (MetaTable)Tables["flowchart_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable flowchart 		=> (MetaTable)Tables["flowchart"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable exportdefinitionflowchart 		=> (MetaTable)Tables["exportdefinitionflowchart"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable menuwebtreeview 		=> (MetaTable)Tables["menuwebtreeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable fileformat 		=> (MetaTable)Tables["fileformat"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable exportdefinition 		=> (MetaTable)Tables["exportdefinition"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_exportdefinition_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_exportdefinition_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_exportdefinition_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_exportdefinition_default.xsd";

	#region create DataTables
	//////////////////// DATATYPE /////////////////////////////////
	var tdatatype= new MetaTable("datatype");
	tdatatype.defineColumn("iddatatype", typeof(int),false);
	tdatatype.defineColumn("title", typeof(string));
	Tables.Add(tdatatype);
	tdatatype.defineKey("iddatatype");

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
	texportdefinitionparameter.defineColumn("!iddatatype_datatype_title", typeof(string));
	Tables.Add(texportdefinitionparameter);
	texportdefinitionparameter.defineKey("idexportdefinition", "idexportdefinitionparameter");

	//////////////////// FLOWCHART_ALIAS1 /////////////////////////////////
	var tflowchart_alias1= new MetaTable("flowchart_alias1");
	tflowchart_alias1.defineColumn("codeflowchart", typeof(string),false);
	tflowchart_alias1.defineColumn("idflowchart", typeof(string),false);
	tflowchart_alias1.defineColumn("title", typeof(string),false);
	tflowchart_alias1.ExtendedProperties["TableForReading"]="flowchart";
	Tables.Add(tflowchart_alias1);
	tflowchart_alias1.defineKey("idflowchart");

	//////////////////// FLOWCHART /////////////////////////////////
	var tflowchart= new MetaTable("flowchart");
	tflowchart.defineColumn("address", typeof(string));
	tflowchart.defineColumn("ayear", typeof(int));
	tflowchart.defineColumn("cap", typeof(string));
	tflowchart.defineColumn("codeflowchart", typeof(string),false);
	tflowchart.defineColumn("ct", typeof(DateTime),false);
	tflowchart.defineColumn("cu", typeof(string),false);
	tflowchart.defineColumn("fax", typeof(string));
	tflowchart.defineColumn("idcity", typeof(int));
	tflowchart.defineColumn("idflowchart", typeof(string),false);
	tflowchart.defineColumn("idsor1", typeof(int));
	tflowchart.defineColumn("idsor2", typeof(int));
	tflowchart.defineColumn("idsor3", typeof(int));
	tflowchart.defineColumn("location", typeof(string));
	tflowchart.defineColumn("lt", typeof(DateTime),false);
	tflowchart.defineColumn("lu", typeof(string),false);
	tflowchart.defineColumn("nlevel", typeof(int),false);
	tflowchart.defineColumn("paridflowchart", typeof(string),false);
	tflowchart.defineColumn("phone", typeof(string));
	tflowchart.defineColumn("printingorder", typeof(string),false);
	tflowchart.defineColumn("title", typeof(string),false);
	Tables.Add(tflowchart);
	tflowchart.defineKey("idflowchart");

	//////////////////// EXPORTDEFINITIONFLOWCHART /////////////////////////////////
	var texportdefinitionflowchart= new MetaTable("exportdefinitionflowchart");
	texportdefinitionflowchart.defineColumn("ct", typeof(DateTime),false);
	texportdefinitionflowchart.defineColumn("cu", typeof(string),false);
	texportdefinitionflowchart.defineColumn("idexportdefinition", typeof(int),false);
	texportdefinitionflowchart.defineColumn("idflowchart", typeof(string),false);
	texportdefinitionflowchart.defineColumn("lt", typeof(DateTime),false);
	texportdefinitionflowchart.defineColumn("lu", typeof(string),false);
	texportdefinitionflowchart.defineColumn("!idflowchart_flowchart_ayear", typeof(int));
	texportdefinitionflowchart.defineColumn("!idflowchart_flowchart_title", typeof(string));
	texportdefinitionflowchart.defineColumn("!idflowchart_flowchart_codeflowchart", typeof(string));
	texportdefinitionflowchart.defineColumn("!idflowchart_flowchart_alias1_codeflowchart", typeof(string));
	texportdefinitionflowchart.defineColumn("!idflowchart_flowchart_alias1_title", typeof(string));
	Tables.Add(texportdefinitionflowchart);
	texportdefinitionflowchart.defineKey("idexportdefinition", "idflowchart");

	//////////////////// MENUWEBTREEVIEW /////////////////////////////////
	var tmenuwebtreeview= new MetaTable("menuwebtreeview");
	tmenuwebtreeview.defineColumn("dropdown_title", typeof(string),false);
	tmenuwebtreeview.defineColumn("idmenuweb", typeof(int),false);
	Tables.Add(tmenuwebtreeview);
	tmenuwebtreeview.defineKey("idmenuweb");

	//////////////////// FILEFORMAT /////////////////////////////////
	var tfileformat= new MetaTable("fileformat");
	tfileformat.defineColumn("idfileformat", typeof(int),false);
	tfileformat.defineColumn("title", typeof(string),false);
	Tables.Add(tfileformat);
	tfileformat.defineKey("idfileformat");

	//////////////////// ATTACH /////////////////////////////////
	var tattach= new MetaTable("attach");
	tattach.defineColumn("attachment", typeof(Byte[]));
	tattach.defineColumn("ct", typeof(DateTime),false);
	tattach.defineColumn("cu", typeof(string),false);
	tattach.defineColumn("filename", typeof(string),false);
	tattach.defineColumn("hash", typeof(string),false);
	tattach.defineColumn("idattach", typeof(int),false);
	tattach.defineColumn("lt", typeof(DateTime),false);
	tattach.defineColumn("lu", typeof(string),false);
	tattach.defineColumn("size", typeof(long),false);
	Tables.Add(tattach);
	tattach.defineKey("idattach");

	//////////////////// EXPORTDEFINITION /////////////////////////////////
	var texportdefinition= new MetaTable("exportdefinition");
	texportdefinition.defineColumn("active", typeof(string));
	texportdefinition.defineColumn("ct", typeof(DateTime),false);
	texportdefinition.defineColumn("cu", typeof(string),false);
	texportdefinition.defineColumn("description", typeof(string));
	texportdefinition.defineColumn("idattach_template", typeof(int));
	texportdefinition.defineColumn("idexportdefinition", typeof(int),false);
	texportdefinition.defineColumn("idfileformat", typeof(int),false);
	texportdefinition.defineColumn("idmenuweb", typeof(int),false);
	texportdefinition.defineColumn("lt", typeof(DateTime),false);
	texportdefinition.defineColumn("lu", typeof(string),false);
	texportdefinition.defineColumn("outputfilename", typeof(string));
	texportdefinition.defineColumn("procedurename", typeof(string));
	texportdefinition.defineColumn("timeoutseconds", typeof(int));
	texportdefinition.defineColumn("title", typeof(string));
	Tables.Add(texportdefinition);
	texportdefinition.defineKey("idexportdefinition");

	#endregion


	#region DataRelation creation
	var cPar = new []{exportdefinition.Columns["idexportdefinition"]};
	var cChild = new []{exportdefinitionparameter.Columns["idexportdefinition"]};
	Relations.Add(new DataRelation("FK_exportdefinitionparameter_exportdefinition_idexportdefinition",cPar,cChild,false));

	cPar = new []{datatype.Columns["iddatatype"]};
	cChild = new []{exportdefinitionparameter.Columns["iddatatype"]};
	Relations.Add(new DataRelation("FK_exportdefinitionparameter_datatype_iddatatype",cPar,cChild,false));

	cPar = new []{exportdefinition.Columns["idexportdefinition"]};
	cChild = new []{exportdefinitionflowchart.Columns["idexportdefinition"]};
	Relations.Add(new DataRelation("FK_exportdefinitionflowchart_exportdefinition_idexportdefinition",cPar,cChild,false));

	cPar = new []{flowchart.Columns["idflowchart"]};
	cChild = new []{exportdefinitionflowchart.Columns["idflowchart"]};
	Relations.Add(new DataRelation("FK_exportdefinitionflowchart_flowchart_idflowchart",cPar,cChild,false));

	cPar = new []{flowchart_alias1.Columns["idflowchart"]};
	cChild = new []{flowchart.Columns["paridflowchart"]};
	Relations.Add(new DataRelation("FK_flowchart_flowchart_alias1_paridflowchart",cPar,cChild,false));

	cPar = new []{menuwebtreeview.Columns["idmenuweb"]};
	cChild = new []{exportdefinition.Columns["idmenuweb"]};
	Relations.Add(new DataRelation("FK_exportdefinition_menuwebtreeview_idmenuweb",cPar,cChild,false));

	cPar = new []{fileformat.Columns["idfileformat"]};
	cChild = new []{exportdefinition.Columns["idfileformat"]};
	Relations.Add(new DataRelation("FK_exportdefinition_fileformat_idfileformat",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{exportdefinition.Columns["idattach_template"]};
	Relations.Add(new DataRelation("FK_exportdefinition_attach_idattach_template",cPar,cChild,false));

	#endregion

}
}
}
