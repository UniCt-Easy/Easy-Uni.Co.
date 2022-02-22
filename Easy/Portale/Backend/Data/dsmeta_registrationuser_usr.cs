
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
[System.Xml.Serialization.XmlRoot("dsmeta_registrationuser_usr"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_registrationuser_usr: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable flowchart 		=> (MetaTable)Tables["flowchart"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrationuserflowchart 		=> (MetaTable)Tables["registrationuserflowchart"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrationuserstatus 		=> (MetaTable)Tables["registrationuserstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable usertype 		=> (MetaTable)Tables["usertype"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrationuser 		=> (MetaTable)Tables["registrationuser"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_registrationuser_usr(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_registrationuser_usr (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_registrationuser_usr";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_registrationuser_usr.xsd";

	#region create DataTables
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

	//////////////////// REGISTRATIONUSERFLOWCHART /////////////////////////////////
	var tregistrationuserflowchart= new MetaTable("registrationuserflowchart");
	tregistrationuserflowchart.defineColumn("idflowchart", typeof(string),false);
	tregistrationuserflowchart.defineColumn("idregistrationuser", typeof(int),false);
	Tables.Add(tregistrationuserflowchart);
	tregistrationuserflowchart.defineKey("idflowchart", "idregistrationuser");

	//////////////////// REGISTRATIONUSERSTATUS /////////////////////////////////
	var tregistrationuserstatus= new MetaTable("registrationuserstatus");
	tregistrationuserstatus.defineColumn("idregistrationuserstatus", typeof(int),false);
	tregistrationuserstatus.defineColumn("title", typeof(string));
	Tables.Add(tregistrationuserstatus);
	tregistrationuserstatus.defineKey("idregistrationuserstatus");

	//////////////////// USERTYPE /////////////////////////////////
	var tusertype= new MetaTable("usertype");
	tusertype.defineColumn("usertype", typeof(string),false);
	Tables.Add(tusertype);
	tusertype.defineKey("usertype");

	//////////////////// REGISTRATIONUSER /////////////////////////////////
	var tregistrationuser= new MetaTable("registrationuser");
	tregistrationuser.defineColumn("cf", typeof(string),false);
	tregistrationuser.defineColumn("email", typeof(string));
	tregistrationuser.defineColumn("esercizio", typeof(int));
	tregistrationuser.defineColumn("forename", typeof(string));
	tregistrationuser.defineColumn("idregistrationuser", typeof(int),false);
	tregistrationuser.defineColumn("idregistrationuserstatus", typeof(int));
	tregistrationuser.defineColumn("login", typeof(string));
	tregistrationuser.defineColumn("matricola", typeof(string));
	tregistrationuser.defineColumn("surname", typeof(string));
	tregistrationuser.defineColumn("userkind", typeof(int));
	tregistrationuser.defineColumn("usertype", typeof(string));
	Tables.Add(tregistrationuser);
	tregistrationuser.defineKey("idregistrationuser");

	#endregion


	#region DataRelation creation
	var cPar = new []{registrationuser.Columns["idregistrationuser"]};
	var cChild = new []{registrationuserflowchart.Columns["idregistrationuser"]};
	Relations.Add(new DataRelation("FK_registrationuserflowchart_registrationuser_idregistrationuser",cPar,cChild,false));

	cPar = new []{flowchart.Columns["idflowchart"]};
	cChild = new []{registrationuserflowchart.Columns["idflowchart"]};
	Relations.Add(new DataRelation("FK_registrationuserflowchart_flowchart_idflowchart",cPar,cChild,false));

	cPar = new []{registrationuserstatus.Columns["idregistrationuserstatus"]};
	cChild = new []{registrationuser.Columns["idregistrationuserstatus"]};
	Relations.Add(new DataRelation("FK_registrationuser_registrationuserstatus_idregistrationuserstatus",cPar,cChild,false));

	cPar = new []{usertype.Columns["usertype"]};
	cChild = new []{registrationuser.Columns["usertype"]};
	Relations.Add(new DataRelation("FK_registrationuser_usertype_usertype",cPar,cChild,false));

	#endregion

}
}
}
