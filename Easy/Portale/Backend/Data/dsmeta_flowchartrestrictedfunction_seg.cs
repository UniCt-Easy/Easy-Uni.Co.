
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
[System.Xml.Serialization.XmlRoot("dsmeta_flowchartrestrictedfunction_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_flowchartrestrictedfunction_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable restrictedfunction 		=> (MetaTable)Tables["restrictedfunction"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable flowchartrestrictedfunction 		=> (MetaTable)Tables["flowchartrestrictedfunction"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_flowchartrestrictedfunction_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_flowchartrestrictedfunction_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_flowchartrestrictedfunction_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_flowchartrestrictedfunction_seg.xsd";

	#region create DataTables
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

	#endregion


	#region DataRelation creation
	var cPar = new []{restrictedfunction.Columns["idrestrictedfunction"]};
	var cChild = new []{flowchartrestrictedfunction.Columns["idrestrictedfunction"]};
	Relations.Add(new DataRelation("FK_flowchartrestrictedfunction_restrictedfunction_idrestrictedfunction",cPar,cChild,false));

	#endregion

}
}
}
