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
[System.Xml.Serialization.XmlRoot("dsmeta_exportdefinitionflowchart_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_exportdefinitionflowchart_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable flowchartsegammview 		=> (MetaTable)Tables["flowchartsegammview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable exportdefinitionflowchart 		=> (MetaTable)Tables["exportdefinitionflowchart"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_exportdefinitionflowchart_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_exportdefinitionflowchart_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_exportdefinitionflowchart_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_exportdefinitionflowchart_default.xsd";

	#region create DataTables
	//////////////////// FLOWCHARTSEGAMMVIEW /////////////////////////////////
	var tflowchartsegammview= new MetaTable("flowchartsegammview");
	tflowchartsegammview.defineColumn("dropdown_title", typeof(string),false);
	tflowchartsegammview.defineColumn("flowchart_address", typeof(string));
	tflowchartsegammview.defineColumn("flowchart_ayear", typeof(int));
	tflowchartsegammview.defineColumn("flowchart_cap", typeof(string));
	tflowchartsegammview.defineColumn("flowchart_codeflowchart", typeof(string),false);
	tflowchartsegammview.defineColumn("flowchart_ct", typeof(DateTime),false);
	tflowchartsegammview.defineColumn("flowchart_cu", typeof(string),false);
	tflowchartsegammview.defineColumn("flowchart_fax", typeof(string));
	tflowchartsegammview.defineColumn("flowchart_idcity", typeof(int));
	tflowchartsegammview.defineColumn("flowchart_idsor1", typeof(int));
	tflowchartsegammview.defineColumn("flowchart_idsor2", typeof(int));
	tflowchartsegammview.defineColumn("flowchart_idsor3", typeof(int));
	tflowchartsegammview.defineColumn("flowchart_location", typeof(string));
	tflowchartsegammview.defineColumn("flowchart_lt", typeof(DateTime),false);
	tflowchartsegammview.defineColumn("flowchart_lu", typeof(string),false);
	tflowchartsegammview.defineColumn("flowchart_nlevel", typeof(int),false);
	tflowchartsegammview.defineColumn("flowchart_phone", typeof(string));
	tflowchartsegammview.defineColumn("flowchart_printingorder", typeof(string),false);
	tflowchartsegammview.defineColumn("flowchartparent_codeflowchart", typeof(string));
	tflowchartsegammview.defineColumn("flowchartparent_title", typeof(string));
	tflowchartsegammview.defineColumn("idflowchart", typeof(string),false);
	tflowchartsegammview.defineColumn("paridflowchart", typeof(string),false);
	tflowchartsegammview.defineColumn("title", typeof(string),false);
	Tables.Add(tflowchartsegammview);
	tflowchartsegammview.defineKey("idflowchart");

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
	var cPar = new []{flowchartsegammview.Columns["idflowchart"]};
	var cChild = new []{exportdefinitionflowchart.Columns["idflowchart"]};
	Relations.Add(new DataRelation("FK_exportdefinitionflowchart_flowchartsegammview_idflowchart",cPar,cChild,false));

	#endregion

}
}
}
