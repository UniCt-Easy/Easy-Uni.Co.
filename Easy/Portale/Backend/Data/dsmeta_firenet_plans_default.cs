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
[System.Xml.Serialization.XmlRoot("dsmeta_firenet_plans_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_firenet_plans_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable firenet_plans 		=> (MetaTable)Tables["firenet_plans"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_firenet_plans_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_firenet_plans_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_firenet_plans_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_firenet_plans_default.xsd";

	#region create DataTables
	//////////////////// FIRENET_PLANS /////////////////////////////////
	var tfirenet_plans= new MetaTable("firenet_plans");
	tfirenet_plans.defineColumn("anno_frequenza", typeof(int));
	tfirenet_plans.defineColumn("anno_frequenza_parziale", typeof(int));
	tfirenet_plans.defineColumn("anno_frequenza_parziale_temp", typeof(int));
	tfirenet_plans.defineColumn("anno_frequenza_temp", typeof(int));
	tfirenet_plans.defineColumn("application_id", typeof(int));
	tfirenet_plans.defineColumn("course_id", typeof(int));
	tfirenet_plans.defineColumn("created", typeof(DateTime));
	tfirenet_plans.defineColumn("crediti", typeof(int));
	tfirenet_plans.defineColumn("date", typeof(DateTime));
	tfirenet_plans.defineColumn("debito", typeof(int));
	tfirenet_plans.defineColumn("durata_assenza_real", typeof(string));
	tfirenet_plans.defineColumn("durata_frequenza", typeof(int));
	tfirenet_plans.defineColumn("durata_frequenza_real", typeof(string));
	tfirenet_plans.defineColumn("edit_operator_user_id", typeof(int));
	tfirenet_plans.defineColumn("exam_id", typeof(int));
	tfirenet_plans.defineColumn("extra", typeof(int));
	tfirenet_plans.defineColumn("id", typeof(int),false);
	tfirenet_plans.defineColumn("modified", typeof(DateTime));
	tfirenet_plans.defineColumn("mutuato", typeof(int));
	tfirenet_plans.defineColumn("note", typeof(string));
	tfirenet_plans.defineColumn("operator_user_id", typeof(int));
	tfirenet_plans.defineColumn("qualification_id", typeof(string));
	tfirenet_plans.defineColumn("student_id", typeof(int));
	tfirenet_plans.defineColumn("teacher_id", typeof(string));
	tfirenet_plans.defineColumn("teaching_id", typeof(int));
	tfirenet_plans.defineColumn("teachingstatus_id", typeof(int));
	tfirenet_plans.defineColumn("temp", typeof(int));
	tfirenet_plans.defineColumn("typology_id", typeof(string));
	tfirenet_plans.defineColumn("voto", typeof(int));
	Tables.Add(tfirenet_plans);
	tfirenet_plans.defineKey("id");

	#endregion

}
}
}
