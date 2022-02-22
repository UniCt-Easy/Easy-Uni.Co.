
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_registrationuserflowchart_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_registrationuserflowchart_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable flowchartsegview 		=> (MetaTable)Tables["flowchartsegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrationuserflowchart 		=> (MetaTable)Tables["registrationuserflowchart"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_registrationuserflowchart_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_registrationuserflowchart_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_registrationuserflowchart_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_registrationuserflowchart_default.xsd";

	#region create DataTables
	//////////////////// FLOWCHARTSEGVIEW /////////////////////////////////
	var tflowchartsegview= new MetaTable("flowchartsegview");
	tflowchartsegview.defineColumn("codeflowchart", typeof(string),false);
	tflowchartsegview.defineColumn("dropdown_title", typeof(string),false);
	tflowchartsegview.defineColumn("flowchart_address", typeof(string));
	tflowchartsegview.defineColumn("flowchart_ayear", typeof(int));
	tflowchartsegview.defineColumn("flowchart_cap", typeof(string));
	tflowchartsegview.defineColumn("flowchart_ct", typeof(DateTime),false);
	tflowchartsegview.defineColumn("flowchart_cu", typeof(string),false);
	tflowchartsegview.defineColumn("flowchart_fax", typeof(string));
	tflowchartsegview.defineColumn("flowchart_idcity", typeof(int));
	tflowchartsegview.defineColumn("flowchart_idsor1", typeof(int));
	tflowchartsegview.defineColumn("flowchart_idsor2", typeof(int));
	tflowchartsegview.defineColumn("flowchart_idsor3", typeof(int));
	tflowchartsegview.defineColumn("flowchart_location", typeof(string));
	tflowchartsegview.defineColumn("flowchart_lt", typeof(DateTime),false);
	tflowchartsegview.defineColumn("flowchart_lu", typeof(string),false);
	tflowchartsegview.defineColumn("flowchart_nlevel", typeof(int),false);
	tflowchartsegview.defineColumn("flowchart_phone", typeof(string));
	tflowchartsegview.defineColumn("flowchart_printingorder", typeof(string),false);
	tflowchartsegview.defineColumn("flowchart_title", typeof(string),false);
	tflowchartsegview.defineColumn("flowchartparent_codeflowchart", typeof(string));
	tflowchartsegview.defineColumn("flowchartparent_title", typeof(string));
	tflowchartsegview.defineColumn("idflowchart", typeof(string),false);
	tflowchartsegview.defineColumn("paridflowchart", typeof(string),false);
	Tables.Add(tflowchartsegview);
	tflowchartsegview.defineKey("idflowchart");

	//////////////////// REGISTRATIONUSERFLOWCHART /////////////////////////////////
	var tregistrationuserflowchart= new MetaTable("registrationuserflowchart");
	tregistrationuserflowchart.defineColumn("idflowchart", typeof(string),false);
	tregistrationuserflowchart.defineColumn("idregistrationuser", typeof(int),false);
	Tables.Add(tregistrationuserflowchart);
	tregistrationuserflowchart.defineKey("idflowchart", "idregistrationuser");

	#endregion


	#region DataRelation creation
	var cPar = new []{flowchartsegview.Columns["idflowchart"]};
	var cChild = new []{registrationuserflowchart.Columns["idflowchart"]};
	Relations.Add(new DataRelation("FK_registrationuserflowchart_flowchartsegview_idflowchart",cPar,cChild,false));

	#endregion

}
}
}
