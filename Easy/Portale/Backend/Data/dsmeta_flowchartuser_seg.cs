
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
[System.Xml.Serialization.XmlRoot("dsmeta_flowchartuser_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_flowchartuser_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable customuser 		=> (MetaTable)Tables["customuser"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable flowchartuser 		=> (MetaTable)Tables["flowchartuser"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_flowchartuser_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_flowchartuser_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_flowchartuser_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_flowchartuser_seg.xsd";

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

	#endregion


	#region DataRelation creation
	var cPar = new []{customuser.Columns["idcustomuser"]};
	var cChild = new []{flowchartuser.Columns["idcustomuser"]};
	Relations.Add(new DataRelation("FK_flowchartuser_customuser_idcustomuser",cPar,cChild,false));

	#endregion

}
}
}
