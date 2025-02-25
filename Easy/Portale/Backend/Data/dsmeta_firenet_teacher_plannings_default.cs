
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_firenet_teacher_plannings_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_firenet_teacher_plannings_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable firenet_teacher_plannings 		=> (MetaTable)Tables["firenet_teacher_plannings"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_firenet_teacher_plannings_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_firenet_teacher_plannings_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_firenet_teacher_plannings_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_firenet_teacher_plannings_default.xsd";

	#region create DataTables
	//////////////////// FIRENET_TEACHER_PLANNINGS /////////////////////////////////
	var tfirenet_teacher_plannings= new MetaTable("firenet_teacher_plannings");
	tfirenet_teacher_plannings.defineColumn("classroom_id", typeof(int));
	tfirenet_teacher_plannings.defineColumn("created", typeof(DateTime));
	tfirenet_teacher_plannings.defineColumn("day", typeof(int));
	tfirenet_teacher_plannings.defineColumn("fine", typeof(string));
	tfirenet_teacher_plannings.defineColumn("id", typeof(int),false);
	tfirenet_teacher_plannings.defineColumn("inizio", typeof(string));
	tfirenet_teacher_plannings.defineColumn("modified", typeof(DateTime));
	tfirenet_teacher_plannings.defineColumn("note", typeof(string));
	tfirenet_teacher_plannings.defineColumn("periodo", typeof(int));
	tfirenet_teacher_plannings.defineColumn("qualification_id", typeof(int));
	Tables.Add(tfirenet_teacher_plannings);
	tfirenet_teacher_plannings.defineKey("id");

	#endregion

}
}
}
