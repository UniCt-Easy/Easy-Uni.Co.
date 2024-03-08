
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
[System.Xml.Serialization.XmlRoot("dsmeta_flowchart_segamm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_flowchart_segamm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable customuser 		=> (MetaTable)Tables["customuser"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable flowchartuser 		=> (MetaTable)Tables["flowchartuser"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable restrictedfunction 		=> (MetaTable)Tables["restrictedfunction"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable flowchartrestrictedfunction 		=> (MetaTable)Tables["flowchartrestrictedfunction"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable flowchartsegview 		=> (MetaTable)Tables["flowchartsegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable flowchart 		=> (MetaTable)Tables["flowchart"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_flowchart_segamm(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_flowchart_segamm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_flowchart_segamm";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_flowchart_segamm.xsd";

	#region create DataTables
	//////////////////// CUSTOMUSER /////////////////////////////////
	var tcustomuser= new MetaTable("customuser");
	tcustomuser.defineColumn("idcustomuser", typeof(string),false);
	Tables.Add(tcustomuser);
	tcustomuser.defineKey("idcustomuser");

	//////////////////// FLOWCHARTUSER /////////////////////////////////
	var tflowchartuser= new MetaTable("flowchartuser");
	tflowchartuser.defineColumn("all_sorkind01", typeof(string));
	tflowchartuser.defineColumn("all_sorkind02", typeof(string));
	tflowchartuser.defineColumn("all_sorkind03", typeof(string));
	tflowchartuser.defineColumn("all_sorkind04", typeof(string));
	tflowchartuser.defineColumn("all_sorkind05", typeof(string));
	tflowchartuser.defineColumn("ct", typeof(DateTime),false);
	tflowchartuser.defineColumn("cu", typeof(string),false);
	tflowchartuser.defineColumn("flagdefault", typeof(string),false);
	tflowchartuser.defineColumn("idcustomuser", typeof(string),false);
	tflowchartuser.defineColumn("idflowchart", typeof(string),false);
	tflowchartuser.defineColumn("lt", typeof(DateTime),false);
	tflowchartuser.defineColumn("lu", typeof(string),false);
	tflowchartuser.defineColumn("ndetail", typeof(int),false);
	tflowchartuser.defineColumn("sorkind01_withchilds", typeof(string));
	tflowchartuser.defineColumn("sorkind02_withchilds", typeof(string));
	tflowchartuser.defineColumn("sorkind03_withchilds", typeof(string));
	tflowchartuser.defineColumn("sorkind04_withchilds", typeof(string));
	tflowchartuser.defineColumn("sorkind05_withchilds", typeof(string));
	tflowchartuser.defineColumn("start", typeof(DateTime));
	tflowchartuser.defineColumn("stop", typeof(DateTime));
	tflowchartuser.defineColumn("title", typeof(string));
	Tables.Add(tflowchartuser);
	tflowchartuser.defineKey("idcustomuser", "idflowchart", "ndetail");

	//////////////////// RESTRICTEDFUNCTION /////////////////////////////////
	var trestrictedfunction= new MetaTable("restrictedfunction");
	trestrictedfunction.defineColumn("ct", typeof(DateTime),false);
	trestrictedfunction.defineColumn("cu", typeof(string),false);
	trestrictedfunction.defineColumn("description", typeof(string),false);
	trestrictedfunction.defineColumn("idrestrictedfunction", typeof(int),false);
	trestrictedfunction.defineColumn("lt", typeof(DateTime),false);
	trestrictedfunction.defineColumn("lu", typeof(string),false);
	trestrictedfunction.defineColumn("variablename", typeof(string),false);
	Tables.Add(trestrictedfunction);
	trestrictedfunction.defineKey("idrestrictedfunction");

	//////////////////// FLOWCHARTRESTRICTEDFUNCTION /////////////////////////////////
	var tflowchartrestrictedfunction= new MetaTable("flowchartrestrictedfunction");
	tflowchartrestrictedfunction.defineColumn("ct", typeof(DateTime),false);
	tflowchartrestrictedfunction.defineColumn("cu", typeof(string),false);
	tflowchartrestrictedfunction.defineColumn("idflowchart", typeof(string),false);
	tflowchartrestrictedfunction.defineColumn("idrestrictedfunction", typeof(int),false);
	tflowchartrestrictedfunction.defineColumn("lt", typeof(DateTime),false);
	tflowchartrestrictedfunction.defineColumn("lu", typeof(string),false);
	Tables.Add(tflowchartrestrictedfunction);
	tflowchartrestrictedfunction.defineKey("idflowchart", "idrestrictedfunction");

	//////////////////// FLOWCHARTSEGVIEW /////////////////////////////////
	var tflowchartsegview= new MetaTable("flowchartsegview");
	tflowchartsegview.defineColumn("dropdown_title", typeof(string),false);
	tflowchartsegview.defineColumn("idflowchart", typeof(string),false);
	tflowchartsegview.defineColumn("paridflowchart", typeof(string),false);
	Tables.Add(tflowchartsegview);
	tflowchartsegview.defineKey("idflowchart");

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

	#endregion


	#region DataRelation creation
	var cPar = new []{flowchart.Columns["idflowchart"]};
	var cChild = new []{flowchartuser.Columns["idflowchart"]};
	Relations.Add(new DataRelation("FK_flowchartuser_flowchart_idflowchart",cPar,cChild,false));

	cPar = new []{customuser.Columns["idcustomuser"]};
	cChild = new []{flowchartuser.Columns["idcustomuser"]};
	Relations.Add(new DataRelation("FK_flowchartuser_customuser_idcustomuser",cPar,cChild,false));

	cPar = new []{flowchart.Columns["idflowchart"]};
	cChild = new []{flowchartrestrictedfunction.Columns["idflowchart"]};
	Relations.Add(new DataRelation("FK_flowchartrestrictedfunction_flowchart_idflowchart",cPar,cChild,false));

	cPar = new []{restrictedfunction.Columns["idrestrictedfunction"]};
	cChild = new []{flowchartrestrictedfunction.Columns["idrestrictedfunction"]};
	Relations.Add(new DataRelation("FK_flowchartrestrictedfunction_restrictedfunction_idrestrictedfunction",cPar,cChild,false));

	cPar = new []{flowchartsegview.Columns["idflowchart"]};
	cChild = new []{flowchart.Columns["paridflowchart"]};
	Relations.Add(new DataRelation("FK_flowchart_flowchartsegview_paridflowchart",cPar,cChild,false));

	cPar = new []{flowchart.Columns["idflowchart"]};
	cChild = new []{flowchart.Columns["paridflowchart"]};
	Relations.Add(new DataRelation("FK_flowchart_flowchart_idflowchart",cPar,cChild,false));

	#endregion

}
}
}
