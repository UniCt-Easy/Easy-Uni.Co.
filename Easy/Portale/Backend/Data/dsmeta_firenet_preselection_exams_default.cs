
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
[System.Xml.Serialization.XmlRoot("dsmeta_firenet_preselection_exams_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_firenet_preselection_exams_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable firenet_preselection_exams 		=> (MetaTable)Tables["firenet_preselection_exams"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_firenet_preselection_exams_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_firenet_preselection_exams_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_firenet_preselection_exams_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_firenet_preselection_exams_default.xsd";

	#region create DataTables
	//////////////////// FIRENET_PRESELECTION_EXAMS /////////////////////////////////
	var tfirenet_preselection_exams= new MetaTable("firenet_preselection_exams");
	tfirenet_preselection_exams.defineColumn("chiusura_iscrizioni", typeof(decimal));
	tfirenet_preselection_exams.defineColumn("classroom_id", typeof(int));
	tfirenet_preselection_exams.defineColumn("classroom2_id", typeof(decimal));
	tfirenet_preselection_exams.defineColumn("commissione1", typeof(int));
	tfirenet_preselection_exams.defineColumn("commissione2", typeof(int));
	tfirenet_preselection_exams.defineColumn("commissione3", typeof(decimal));
	tfirenet_preselection_exams.defineColumn("commissione4", typeof(decimal));
	tfirenet_preselection_exams.defineColumn("commissione5", typeof(decimal));
	tfirenet_preselection_exams.defineColumn("commissione6", typeof(decimal));
	tfirenet_preselection_exams.defineColumn("commissione7", typeof(decimal));
	tfirenet_preselection_exams.defineColumn("course_id", typeof(int));
	tfirenet_preselection_exams.defineColumn("created", typeof(DateTime));
	tfirenet_preselection_exams.defineColumn("date", typeof(string));
	tfirenet_preselection_exams.defineColumn("date2", typeof(decimal));
	tfirenet_preselection_exams.defineColumn("edit_operator_user_id", typeof(int));
	tfirenet_preselection_exams.defineColumn("examstatus_id", typeof(int));
	tfirenet_preselection_exams.defineColumn("id", typeof(int),false);
	tfirenet_preselection_exams.defineColumn("modified", typeof(DateTime));
	tfirenet_preselection_exams.defineColumn("note", typeof(string));
	tfirenet_preselection_exams.defineColumn("operator_user_id", typeof(int));
	tfirenet_preselection_exams.defineColumn("preselection_exam_type_id", typeof(int));
	tfirenet_preselection_exams.defineColumn("preselection_session_id", typeof(int));
	tfirenet_preselection_exams.defineColumn("teacher_id", typeof(int));
	Tables.Add(tfirenet_preselection_exams);
	tfirenet_preselection_exams.defineKey("id");

	#endregion

}
}
}
