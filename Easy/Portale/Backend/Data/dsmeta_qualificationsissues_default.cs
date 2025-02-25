
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
[System.Xml.Serialization.XmlRoot("dsmeta_qualificationsissues_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_qualificationsissues_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable issuesq 		=> (MetaTable)Tables["issuesq"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable qualificationsissues 		=> (MetaTable)Tables["qualificationsissues"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_qualificationsissues_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_qualificationsissues_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_qualificationsissues_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_qualificationsissues_default.xsd";

	#region create DataTables
	//////////////////// ISSUESQ /////////////////////////////////
	var tissuesq= new MetaTable("issuesq");
	tissuesq.defineColumn("attribute_name", typeof(string));
	tissuesq.defineColumn("ct", typeof(DateTime),false);
	tissuesq.defineColumn("cu", typeof(string),false);
	tissuesq.defineColumn("idissuesq", typeof(int),false);
	tissuesq.defineColumn("idqualificationsissues", typeof(int),false);
	tissuesq.defineColumn("issue_description", typeof(string));
	tissuesq.defineColumn("lt", typeof(DateTime),false);
	tissuesq.defineColumn("lu", typeof(string),false);
	Tables.Add(tissuesq);
	tissuesq.defineKey("idissuesq", "idqualificationsissues");

	//////////////////// QUALIFICATIONSISSUES /////////////////////////////////
	var tqualificationsissues= new MetaTable("qualificationsissues");
	tqualificationsissues.defineColumn("academic_qualification_date", typeof(string));
	tqualificationsissues.defineColumn("birth_date", typeof(string));
	tqualificationsissues.defineColumn("birth_place", typeof(string));
	tqualificationsissues.defineColumn("ct", typeof(DateTime),false);
	tqualificationsissues.defineColumn("cu", typeof(string),false);
	tqualificationsissues.defineColumn("data_request", typeof(string));
	tqualificationsissues.defineColumn("degree_class_code", typeof(string));
	tqualificationsissues.defineColumn("degree_course_code", typeof(string));
	tqualificationsissues.defineColumn("family_name", typeof(string));
	tqualificationsissues.defineColumn("file_code", typeof(string));
	tqualificationsissues.defineColumn("file_status", typeof(string));
	tqualificationsissues.defineColumn("given_name", typeof(string));
	tqualificationsissues.defineColumn("idqualificationsissues", typeof(int),false);
	tqualificationsissues.defineColumn("institute_code", typeof(string));
	tqualificationsissues.defineColumn("institute_name", typeof(string));
	tqualificationsissues.defineColumn("lt", typeof(DateTime),false);
	tqualificationsissues.defineColumn("lu", typeof(string),false);
	tqualificationsissues.defineColumn("message", typeof(string));
	tqualificationsissues.defineColumn("person_id", typeof(string));
	tqualificationsissues.defineColumn("programme_type_code", typeof(string));
	tqualificationsissues.defineColumn("qualification_grade_value", typeof(string));
	tqualificationsissues.defineColumn("qualification_grading_scale_maximum_grade", typeof(string));
	tqualificationsissues.defineColumn("qualification_grading_scale_minimum_grade", typeof(string));
	tqualificationsissues.defineColumn("qualification_name", typeof(string));
	tqualificationsissues.defineColumn("subscriber_id", typeof(string));
	tqualificationsissues.defineColumn("subscriber_message", typeof(string));
	tqualificationsissues.defineColumn("subscriber_name", typeof(string));
	tqualificationsissues.defineColumn("tax_code", typeof(string));
	Tables.Add(tqualificationsissues);
	tqualificationsissues.defineKey("idqualificationsissues");

	#endregion


	#region DataRelation creation
	var cPar = new []{qualificationsissues.Columns["idqualificationsissues"]};
	var cChild = new []{issuesq.Columns["idqualificationsissues"]};
	Relations.Add(new DataRelation("FK_issuesq_qualificationsissues_idqualificationsissues",cPar,cChild,false));

	#endregion

}
}
}
